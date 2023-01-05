import React from 'react';
import Home from './Home'
import About from './About';
import Edu from './Edu';
import Exp from './Exp';
import Skills from './Skills';
import Contact from './Contact';

function Content(){
    return(
        <>
        <Home />
        <div class="wrapper">
            <About />
            <Edu />
            <Exp />
            <Skills />
            <Contact />
        </div>
        </> 
    )
}

export default Content;