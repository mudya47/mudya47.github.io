import React from 'react';
import Linkedin from './Linkedin';
import Email from './Email';


function Contact() {
  return(
    <div class="contents border-top">
        <h2>Contact Me on</h2>
        <div class="d-flex content-center">
            <div class="left pr-50">
                <Linkedin />
            </div>
            <div class="right">
                <Email />
            </div>
            
        </div>
    </div>
    
    
  )
}
export default Contact;