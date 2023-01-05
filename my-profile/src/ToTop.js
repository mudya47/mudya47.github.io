import React from 'react';
import './ToTop.css';

function ToTop() {
    const handleClick = () => {
      window.scrollTo({ top: 0, behavior: "smooth" });
    };
    
    return <button onClick={handleClick} class="top"></button>;
  }

export default ToTop;