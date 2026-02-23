import React from 'react'
import {House, BarChart, Image} from 'react-bootstrap-icons'

const Sidebar = () => {
    return(
        <div className="bg-light p-3" style={{width:'70px', minHeight:'100vh'}}>
            <div className="d-flex flex-column align-items-center gap-4">
                <House size={24} />
                <BarChart size={24} />
                <Image size={24} />
            </div>
        </div>
    )
}

export default Sidebar