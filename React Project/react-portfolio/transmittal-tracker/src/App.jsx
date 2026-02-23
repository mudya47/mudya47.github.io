import './App.css'
import React from 'react'
import Sidebar from './components/Sidebar'
import Dashboard from './pages/Dashboard'


const App = () => {
  return (
    <div className="d-flex" style={{ minHeight: "100vh" }}>
      <Sidebar />
      <div className="flex-grow-1">
        <Dashboard />
      </div>
    </div>
  )
}

export default App
