import { createBrowserRouter } from "react-router-dom";
import LoginPage from "./components/common/LoginPage";
import SignupPage from "./components/common/SignupPage";
import EmailConfirmationWaiting from "./components/common/EmailConfirmationWaiting"; // Import the component
// import ProfilePage from './components/customer/ProfilePage';
import OrderHistoryPage from "./components/customer/OrderHistoryPage";

import Homepage from "./components/common/Homepages";
import Feedback from "./components/customer/Feedback";
import FeedbackList from "./components/customer/FeedbackList";
// import OrderForm from './components/customer/OrderForm';
import OrderStatusTracking from "./components/customer/OrderStatusTracking";
import TrackingStaff from "./components/admin/TrackingStaff";
import OrdersDashBoard from "./components/admin/OrdersDashBoard";
import PlaceOrder from "./components/customer/PlaceOrder";
// import ProfilePage from "./components/customer/ProfilePage";
// import PrivateRoute from "./components/PrivateRoute";
import UserProfilePage from "./components/customer/profile";
import AddFishForm from "./components/customer/profile/AddFishForm"; // Import AddFishForm
import { StaffDashBoard } from "./components/staff/StaffDashBoard";
import ViewOrderHistory from "./components/customer/profile/ViewOrderHistory"; // Import ViewOrderHistory
import ViewOrderDetails from "./components/customer/profile/ViewOrderDetail";
import NotFound from "./components/common/404page";
import ContactPage from "./components/common/Contact";
import AboutPage from "./components/common/About";
import PaymentSuccess from "./components/common/PaymentSuccess"; // Import PaymentSuccess component
import ForgotPassword from "./components/common/ForgotPassword"; // Import the ForgotPassword component
import AdminPage from "./components/admin/adminpage";
import Dashboard from "./components/deliveryStaff/Dashboard";
import ProfileForm from "./components/customer/profile/ProfileForm";
import IndexUserProfile from "./components/customer/profile";
import HealthCareDashboard from "./components/healthcare/HealthCareDashboard";

export const router = createBrowserRouter([
  {
    path: "/",
    element: <Homepage />,
  },
  {
    path: "*",
    element: <NotFound />,
  },

  {
    path: "/login",
    element: <LoginPage />,
  },
  {
    path: "/signup",
    element: <SignupPage />,
  },
  {
    path: "/email-confirmation-waiting", // Define the new route path
    element: <EmailConfirmationWaiting />, // Set the component as the element
  },
  {
    path: "/profile",
    element: <IndexUserProfile />,
    children: [
      {
        path: "Information",
        element: <ProfileForm />,
      },
      {
        path: "AddFish",
        element: <AddFishForm />,
      },
      {
        path: "ViewOrderHistory",
        element: <ViewOrderHistory />,
      },
    ],
  },
  {
    path: "/orderhistory",
    element: <OrderHistoryPage />,
  },
  {
    path: "/feedback",
    element: <Feedback />,
  },
  {
    path: "/orderform",
    element: <PlaceOrder />,
  },
  {
    path: "/ordersDashBoard",
    element: <OrdersDashBoard />,
  },
  {
    path: "/feedbacklist",
    element: <FeedbackList />,
  },
  {
    path: "/ordertracking",
    element: (
      // <PrivateRoute>
      <OrderStatusTracking />
      // </PrivateRoute>
    ), // Wrapped with PrivateRoute
  },
  {
    path: "/trackingstaff",
    element: <TrackingStaff />,
  },
  // {
  //   path: "/orders/:id",
  //   element: <ViewOrderDetails />,
  // },
  // {
  //   path: "/orders",
  //   element: <ViewOrderHistory />,
  // },
  {
    path: "/staffDashBoard",
    element: (// <PrivateRoute>
        <StaffDashBoard />
    ),
  },
  {
    path: "/profile/ViewOrderHistory/:orderId", // Ensure this matches the path used in handleViewDetail
    element: <ViewOrderDetails />, // Ensure this component is correct
  },
  {
    path: "/contact", // Ensure this matches the path used in handleViewDetail
    element: <ContactPage />, // Ensure this component is correct
  },
  {
    path: "/about", // Define the path for the About page
    element: <AboutPage />, // Set the AboutPage component as the element
  },
  {
    path: "/payment-success", // Define the path for the Payment Success page
    element: <PaymentSuccess />, // Set the PaymentSuccess component as the element
  },
  {
    path: "/forgot-password", // Define the path for the Forgot Password page
    element: <ForgotPassword />, // Set the ForgotPassword component as the element
  },
  {
    path:"delivery-staff",
    element:<Dashboard/>
  },
  {
    path: "/admin",
    element: <AdminPage />,
  },
  {
    path: "/healthcare", // Define the new route path
    element: <HealthCareDashboard />, // Set the component as the element
  },
]);
