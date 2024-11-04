import { baseUrl, headers, getJwtToken } from "./Url";
import axios from "axios";
const getAllStaffURL = baseUrl + "/Staff";

const getHeaders = () => {
  const token = getJwtToken(); // Retrieve the token
  return {
    ...headers,
    'Authorization': `Bearer ${token}`, // Add the token to the headers
  };
};
export async function checkAccountIdExists(accountId) {
  try {
    // Function to check if the accountId exists in the database
    const response = await axios.get(`${getAllStaffURL}/${accountId}`, { headers: getHeaders() });
    return response.data.exists; // Assuming the API returns { exists: true/false }
  } catch (error) {
    console.error('Error checking account existence:', error);
    return false; // Default to false if the request fails
  }
}
export async function GetAllStaffs() {
  var allStaff = null;
  await axios
    .get(getAllStaffURL, { headers: getHeaders() })
    .then((response) => {
      allStaff = response.data;
    })
    .catch((error) => {
      console.error(error);
      alert("Error fetching Staff data");
    });
  return allStaff;
}
// Function to create a new staff member
export async function createNewStaff(staffData) {
  try {
    const response = await axios.post(getAllStaffURL, staffData, { headers: getHeaders() });
    return response.data; // Assuming the API returns the created staff data
  } catch (error) {
    console.error('Error creating new staff:', error);
    throw error; // Rethrow the error for handling in the calling function
  }
}
