import React from 'react';
import profile from './images/profile.jpg';

function About(){
    return(
            <div class="contents">
                <h2  id="about">About me</h2>
                <div class="d-flex">
                    <div class="left">
                        <img src={profile} alt="" width={200} height={200}></img>
                    </div>
                    <div class="right">
                        <p>Was born in 1996, i am now 26 years old. I am a highly motivated to learn and grow and also eager to contribute for team and company success. I can work well as team player but not limited myself to work independently, and also responsible for every task given and finished it with company standard. My experiences helped me to make decisions and take actions that necessary based on the situations.</p>
                    </div>
                    
                </div>
            </div>
    )
}

export default About;