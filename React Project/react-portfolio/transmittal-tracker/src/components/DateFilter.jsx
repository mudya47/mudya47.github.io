import React, {useState} from 'react'

const DateFilter = () => {
    const [startDate, setStartDate] = useState('')
    const [endDate, setEndDate] = useState('')

    const handleFilter = () => {
        console.log('Filter clicked with: ', startDate, endDate)

    }

    const handleClear = () => {
        setStartDate('')
        setEndDate('')
        console.log('Date Cleared')
    }
    
    return (
        <div className="d-flex align-items-end gap-2 mb-3">
            <div>
                <label className="form-label">Date Range Filter</label>
                <input type="date" className="form-control" value={startDate} onChange={(e) => setStartDate(e.target.value)} />
            </div>
            <div>
                <label className="form-label">Date Range Filter</label>
                <input type="date" className="form-control" value={endDate} onChange={(e) => setEndDate(e.target.value)} />
            </div>
            <div className="d-flex gap-1">
                <button className="btn btn-primary" onClick={handleFilter}>Filter</button>
                <button className="btn btn-secondary" onClick={handleClear}>Clear</button>
            </div>
        </div>
    )
}

export default DateFilter