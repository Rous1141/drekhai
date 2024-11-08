﻿using System;
using KDOS_Web_API.Datas;
using KDOS_Web_API.Models.Domains;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;

namespace KDOS_Web_API.Repositories
{
    // The impliment class - just like the cotroller
    public class SQLAccountRepository : IAccountRepository
    {
        private readonly KDOSDbContext accountContext;

        public SQLAccountRepository(KDOSDbContext accountContext)
        {
            this.accountContext = accountContext;
        }
        // The job of the reposiory is to access the Datebase, not the controller
        public async Task<List<Account>> GetAllAccountAsync()
        {
            return await accountContext.Account.ToListAsync();
        }
        public async Task<Account?> GetAccountById(int id)
        {
            return await accountContext.Account.Include(x=>x.Customer).FirstOrDefaultAsync(x => x.AccountId == id);
        }

        public async Task<Account?> AddNewAccount(Account account)
        {
            var accountList = await accountContext.Account.ToListAsync();
            foreach (Account accountModel in accountList)
            {
                if (accountModel.Email.Equals(account.Email) || accountModel.UserName.Equals(account.UserName))
                {
                    return null;
                }
            }
            await accountContext.Account.AddAsync(account);
            await accountContext.SaveChangesAsync();
            return account;
        }

        public async Task<Account?> DeleteAccount(int id)
        {
           var accountExist = await accountContext.Account.FirstOrDefaultAsync(x => x.AccountId == id);
            if (accountExist == null)
            {
                return null;
            }
            else
            {
                accountContext.Account.Remove(accountExist);
                await accountContext.SaveChangesAsync();
                return accountExist;
            }
           
        }

        public async Task<Account?> UpdateAccount(int id, Account account)
        {
            var accountExist = await accountContext.Account.FirstOrDefaultAsync(x => x.AccountId == id);
            var emailExist = await accountContext.Account.FirstOrDefaultAsync(x => x.Email == account.Email|| x.UserName == account.UserName);
            var usernameExist = await accountContext.Account.FirstOrDefaultAsync(x =>x.UserName == account.UserName);
            if (accountExist == null || emailExist != null || usernameExist!=null)
            {
                return null;
            }
            else
            {
                accountExist.UserName = account.UserName;
                accountExist.Email = account.Email;
                await accountContext.SaveChangesAsync();
                return accountExist;
            }
        }

        public async Task<Account?> UpdateAvatar(int id, Account account)
        {
            var accountExist = await accountContext.Account.FirstOrDefaultAsync(x => x.AccountId == id);
            if (accountExist == null)
            {
                return null;
            }
            else
            {
                accountExist.Avatar = account.Avatar;
                await accountContext.SaveChangesAsync();
                return accountExist;
            }
        }

        public async Task<Account?> UpdatePassword(int id, Account account)
        {
            var accountExist = await accountContext.Account.FirstOrDefaultAsync(x => x.AccountId == id);
            if (accountExist == null)
            {
                return null;
            }
            else
            {
                accountExist.Password = account.Password;
                await accountContext.SaveChangesAsync();
                return accountExist;
            }
        }

        public async Task<Account?> Login(string userNameOrEmail)
        {
            return await accountContext.Account.Include(x=>x.Customer).Include(x=>x.Staff).Include(x=>x.DeliveryStaff).FirstOrDefaultAsync(x => x.UserName == userNameOrEmail || x.Email == userNameOrEmail);
        }

        public async Task<Account?> BanAccount(int id, Account account)
        {
            var accountExist = await accountContext.Account.FirstOrDefaultAsync(x => x.AccountId == id);
            if (accountExist == null || !accountExist.Role.Equals("customer"))
            {
                return null;
            }
            else
            {
                accountExist.Banned = account.Banned;
                await accountContext.SaveChangesAsync();
                return account;
            }
        }

        public async Task<Account?> VerificationAccount(Account account, Verification verification)
        {
            var verificationModel = await accountContext.Verification.FirstOrDefaultAsync(x=>x.AccountId== account.AccountId);
            if (verificationModel==null) // check for darty little cheater
            {
                return null;
            }
            else if(verificationModel.ExpiredDate < verification.ExpiredDate) //delete expired token too, because they are taking up space
            {
                accountContext.Verification.Remove(verification);
                await accountContext.SaveChangesAsync();
                return null;
            }
            accountContext.Verification.Remove(verification);
            var accountExist = await accountContext.Account.FirstOrDefaultAsync(x => x.AccountId == account.AccountId);
            // Account is guarantee in DB
            accountExist!.Verified = account.Verified;
            await accountContext.SaveChangesAsync(); // Update account to "verified"
            return accountExist;
        }

        public async Task<Account?> VerificationMailing(Account account, Verification verification)
        {
            // Incase of re-verification, delete the old verification
            var verificationExist = await accountContext.Verification.FirstOrDefaultAsync(x => x.AccountId == verification.AccountId);
            if (verificationExist!=null)
            {
                accountContext.Verification.Remove(verificationExist);
                await accountContext.SaveChangesAsync();
            }
            // Add a new verification
            await accountContext.Verification.AddAsync(verification);
            await accountContext.SaveChangesAsync();
            return account;
        }

        public async Task<Verification?> FindVerificationWithAccountId(int id)
        {
            var verificationExist = await accountContext.Verification.FirstOrDefaultAsync(x => x.AccountId == id);
            if (verificationExist == null)
            {
                return null;
            }
            else
            {
                return verificationExist;
            }
        }
        public async Task<bool> ToggleBannedStatusAsync(int userId)
        {
            // Find the user by ID
            var user = await accountContext.Account.FindAsync(userId);

            if (user == null)
            {
                return false; // User not found
            }

            // Toggle the Banned status (true becomes false, and false becomes true)
            user.Banned = !user.Banned;

            // Save changes to the database
            await accountContext.SaveChangesAsync();

            return true;
        }
        public async Task<Account?> UpdateRole(int id, Account account)
        {
            var accountExist = await accountContext.Account.FirstOrDefaultAsync(x => x.AccountId == id);
            if (accountExist == null)
            {
                return null;
            }
            else
            {
                accountExist.Role = account.Role;
                await accountContext.SaveChangesAsync();
                return accountExist;
            }   
        }
        public async Task<bool> CheckExistedAccountId(int id)
        {
            var accountExist = await accountContext.Account.FirstOrDefaultAsync(x => x.AccountId == id);
            if (accountExist == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}

