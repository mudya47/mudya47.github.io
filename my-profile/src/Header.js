import React from 'react';
import './Header.css';

function Header() {
    const scrollToElement = (event) => {
      event.preventDefault();
      const element = document.getElementById("about");
      element.scrollIntoView({ behavior: "smooth" });
    };

    const scrollToElement1 = (event) => {
        event.preventDefault();
        const element = document.getElementById("edu");
        element.scrollIntoView({ behavior: "smooth" });
    };

    const scrollToElement2 = (event) => {
        event.preventDefault();
        const element = document.getElementById("exp");
        element.scrollIntoView({ behavior: "smooth" });
    };

    const scrollToElement3 = (event) => {
        event.preventDefault();
        const element = document.getElementById("skill");
        element.scrollIntoView({ behavior: "smooth" });
    };
  
    return (
        <div class="header">
            <div class="d-flex navBar">
                <p><a href="#about" onClick={scrollToElement}>About</a></p>
                <p><a href="#edu" onClick={scrollToElement1}>Education</a></p>
                <p><a href="#exp" onClick={scrollToElement2}>Experience</a></p>
                <p><a href="#skill" onClick={scrollToElement3}>Skills</a></p>
            </div>
        </div>
    );
  }

export default Header;