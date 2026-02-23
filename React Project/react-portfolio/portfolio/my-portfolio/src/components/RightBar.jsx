import React from 'react'

function RightBar(){
    return(
        <div className="right-display">
            <div id="about">
                <p>Front-end focused IT professional with 3+ years of experience managing CMS platforms, building production-ready HTML/CSS/JavaScript pages, and supporting large-scale web operations. Experienced in cross-browser optimization, UI implementation, and turning design mockups into clean, maintainable code. Currently working in ERP administration and internal web app development (Blazor & Azure), bringing a strong system-thinking approach to frontend development while still balancing usability, performance, and operational needs.</p>
            </div>
            <div id="experience">
                <div className="years">
                    <p>2024 - Current</p>
                </div>
                <div className="company">
                    <p>ERP Administrator/IT Support/Beginner Full Stack Dev</p>
                    <p>ODG Indonesia</p>
                    <ol>
                        <li><strong>System Administration</strong>: Run Simpro ERP for three ODG entities: manage user accounts, handle access requests, troubleshoot issues, and keep the system running. Field questions from users across Indonesia and PNG, configure platform settings as needed</li>
                        <li><strong>Data Management</strong>: Process job creation and purchase orders across multiple branches, ensuring data accuracy and operational efficiency</li>                        
                        <li><strong>User Support & Process Improvement</strong>: Watch how people use the system, collect feedback, and find ways to make things clearer. Reduced confusion around key features by updating documentation and running quick training sessions</li>
                        <li><strong>Team Collaboration</strong>: Act as the bridge between users and the dev team. Take business needs, explain them to developers in tech terms, then explain solutions back to users in plain language</li>
                        <li><strong>Internal Tools Development</strong>: Built internal web apps with C#, Blazor, and Azure, including a vehicle tracking system that helps manage our fleet across branches</li>
                    </ol>
                </div>
            </div>
            <div id="experience">
                <div className="years">
                    <p>2019 - 2022</p>
                </div>
                <div className="company">
                    <p>Web Administrator</p>
                    <p>Transcosmos Indonesia</p>
                    <ol>
                        <li><strong>Platform Configuration</strong>: Managed and configured company-specific CMS for landing page development supporting ANA (All Nippon Airways) marketing campaigns</li>
                        <li><strong>Data & Content Management</strong>: Updated and maintained client websites with accurate content, ensuring timely delivery and engagement</li>
                        <li><strong>Quality Assurance</strong>: Conducted thorough cross-browser and cross-device testing to ensure platform compatibility and consistent user experience</li>
                        <li><strong>Process Adherence</strong>:  Followed SOPs for version control using custom Git system, enabling efficient collaboration and tracking across teams</li>
                        <li><strong>Task Management</strong>: Performed scheduled monthly maintenance updates, ensuring websites remained current, secure, and fully operational</li>
                    </ol>
                </div>
                <p><a href="" target="_blank" className="download">View Full Resume</a></p>
            </div>
            <div id="projects">
                <p>test</p>
            </div>
            <p>Page design taken and inspired by<br/><a href="https://brittanychiang.com/" target="_blank">https://brittanychiang.com/</a></p>
        </div>
    )
}

export default RightBar;