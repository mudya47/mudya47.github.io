import React, { useState } from 'react';
import inblack from './images/inblack.svg';
import incolor from './images/incolor.svg';

function Linkedin() {
  const [isHovered, setIsHovered] = useState(false);

  return (
    <div
      onMouseOver={() => setIsHovered(true)}
      onMouseOut={() => setIsHovered(false)}
    >
      {isHovered ? (
        <a href="https://www.linkedin.com/in/eka-pramudya/"><img src={incolor} alt="linked-in" width={50} height={50} class="img"/></a>
      ) : (
        <img src={inblack} alt="linked-in" width={50} height={50}  class="img"/>
      )}
    </div>
  );
}
export default Linkedin;