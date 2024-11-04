
import { useState } from 'react';
import HistoryIcon from '@mui/icons-material/History';
import LocalShippingIcon from '@mui/icons-material/LocalShipping'
import "../../css/DeliveryStaffMenu.css"
import { Person } from '@mui/icons-material';
import { Panel } from 'primereact/panel';
import { Divider } from 'primereact/divider';
        
export default function DeliveryStaffMenu({ setSelectedMenu }) {
    const [hoveredItem, setHoveredItem] = useState(null);
    return (
        <div class="nav-dock">
            <h2 className="nav-header">Delivery Staff</h2>
            <a
                className="nav-item"
                onMouseEnter={() => setHoveredItem("transport")}
                onClick={() => setSelectedMenu("transport")}
            >
                <LocalShippingIcon />
                {hoveredItem === "transport" && (
                    <span className="nav-description">View Current Transport</span>
                )}
            </a>

            <a
                className="nav-item"
                onMouseEnter={() => setHoveredItem("history")}
                onClick={() => setSelectedMenu("history")}
            >
                <HistoryIcon />
                {hoveredItem === "history" && (
                    <span className="nav-description">View All Of Your Transport </span>
                )}
            </a>
            <a
                className="nav-item"
                onMouseEnter={() => setHoveredItem("profile")}
                onClick={() => setSelectedMenu("profile")}
            >
                <Person />
                {hoveredItem === "profile" && (
                    <span className="nav-description">View Your Profile</span>
                )}
            </a>
        </div>
       
    )
}
