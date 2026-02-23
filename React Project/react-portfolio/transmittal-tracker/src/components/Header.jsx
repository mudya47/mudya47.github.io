import React from 'react'

const Header = () => {
    return(
        <div className="d-flex justify-content-between align-items-center mb-3 border-bottom pb-2">
            <h5 className="mb-0">Dashboard</h5>

            <div className="d-flex align-items-center gap-3">
                <input type="text" className="form-control" placeholder="Search" style={{maxWidth: '200px'}} />
                <select className="form-select" style={{maxWidth: '120px'}}>
                    <option>Quick Filter</option>
                    <option>Today</option>
                    <option>This Week</option>
                </select>
                <div>#Username</div>
                <button className="btn btn-outline-danger btn-sm">Logout</button>
            </div>
        </div>
    )
}

export default Header