import React from 'react';
import profile from './images/profile.jpg';

function About(){
    return(
            <div class="contents mw-1024">
                <h2  id="about">About me</h2>
                <div class="d-flex">
                    <div class="left flex-width-30 img-100">
                        <img src={profile} alt="" width="" height=""></img>
                    </div>
                    <div class="right flex-width-70">
                        <p>Was born in 1996, i am now 26 years old. I am a highly motivated to learn and grow and also eager to contribute for team and company success. I can work well as team player but not limited myself to work independently, and also responsible for every task given and finished it with company standard. My experiences helped me to make decisions and take actions that necessary based on the situations.</p>
                    </div>
                    
                </div>
            </div>
    )
}

export default About;