import React, { useState } from 'react';
import mailblack from './images/mailblack.svg';
import mailcolor from './images/mailcolor.svg';

function Email() {
  const [isHovered, setIsHovered] = useState(false);

  return (
    <div
      onMouseOver={() => setIsHovered(true)}
      onMouseOut={() => setIsHovered(false)}
    >
      {isHovered ? (
        <a href="mailto:ekapramudya364@gmail.com"><img src={mailcolor} alt="linked-in" width={50} height={50} class="img"/></a>
      ) : (
        <img src={mailblack} alt="linked-in" width={50} height={50}  class="img"/>
      )}
    </div>
  );
}
export default Email;