import React from 'react';
import './Header.css';


function Header (){
    return(
        <div class="header">
            <div class="d-flex navBar">
                <p><a href="#home">Home</a></p>
                <p><a href="#about">About</a></p>
                <p><a href="#edu">Edu</a></p>
                <p><a href="#exp">Experiences</a></p>
                <p><a href="#skill">Skills</a></p>
            </div>
        </div>
    )
}

export default Header;