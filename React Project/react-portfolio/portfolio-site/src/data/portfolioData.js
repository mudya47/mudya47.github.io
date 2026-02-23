/**
 * Portfolio Data
 * 
 * KENAPA FILE INI PENTING?
 * - Separation of Concerns: Data terpisah dari UI logic
 * - Single Source of Truth: Semua content di satu tempat
 * - Easy to Update: Ubah content tanpa touch component code
 * - Scalable: Bisa fetch dari API nanti tanpa ubah component
 */

export const personalInfo = {
  name: "Brittany Chiang",
  title: "Frontend Engineer",
  tagline: "I build accessible, pixel-perfect digital experiences for the web.",
  
  // Social media links
  social: {
    github: "https://github.com/bchiang7",
    linkedin: "https://www.linkedin.com/in/bchiang7/",
    twitter: "https://twitter.com/bchiang7",
    instagram: "https://www.instagram.com/bchiang7/",
    codepen: "https://codepen.io/bchiang7"
  }
};

/**
 * Experience Data
 * Array of objects - setiap object represent satu experience
 */
export const experiences = [
  {
    id: 1,
    title: "Lead Engineer - Upstatement",
    position: "Senior Engineer → Engineer",
    period: "2018 — 2024",
    description: "Build, style, and ship high-quality websites, design systems, mobile apps, and digital experiences for a diverse array of projects for clients including Harvard Business School, Everytown for Gun Safety, Pratt Institute, Koala Health, Vanderbilt University, The 19th News, and more. Provide leadership within engineering department through close collaboration, knowledge shares, and spearheading the development of internal tools.",
    tags: ["JavaScript", "TypeScript", "React", "Storybook"],
    skills: ["HTML & SCSS", "React Native", "WordPress", "Contentful", "Node.js", "PHP"],
    link: null
  },
  {
    id: 2,
    title: "UI Engineer Co-op - Apple",
    position: "",
    period: "JULY — DEC 2017",
    description: "Developed and styled interactive web apps for Apple Music, including the user interface of Apple Music's embeddable web player widget for in-browser user authorization and full song playback.",
    tags: ["MusicKit.js", "BrooklJS", "The Verge"],
    skills: ["Ember", "SCSS", "JavaScript", "MusicKit.js"],
    link: null
  },
  {
    id: 3,
    title: "Developer - Scout Studio",
    position: "",
    period: "2016 — 2017",
    description: "Collaborated with other student designers and engineers on pro-bono projects to create new brands, design systems, and websites for organizations in the community.",
    tags: [],
    skills: ["Jekyll", "SCSS", "JavaScript", "WordPress"],
    link: null
  }
];

/**
 * Projects Data
 * Featured projects untuk portfolio section
 */
export const projects = [
  {
    id: 1,
    title: "Build a Spotify Connected App",
    year: "2024",
    description: "Video course that teaches how to build a web app with the Spotify Web API. Topics covered include the principles of REST APIs, user auth flows, Node, Express, React, Styled Components, and more.",
    image: "/images/spotify-app.png", // Path relatif ke public folder
    stats: {
      stars: null,
      installs: null
    },
    tags: ["React", "Express", "Spotify API", "Heroku"],
    link: "https://spotify-connected-app.com"
  },
  {
    id: 2,
    title: "Spotify Profile",
    year: "",
    description: "Web app for visualizing personalized Spotify data. View your top artists, top tracks, recently played tracks, and detailed audio information about each track. Create and save new playlists of recommended tracks based on your existing playlists and more.",
    image: "/images/spotify-profile.png",
    stats: {
      stars: 707,
      installs: null
    },
    tags: ["React", "Express", "Spotify API", "Heroku"],
    link: "https://spotify-profile.com"
  },
  {
    id: 3,
    title: "Halcyon Theme",
    year: "",
    description: "Minimal dark blue theme for VS Code, Sublime Text, Atom, iTerm, and more.",
    image: "/images/halcyon-theme.png",
    stats: {
      stars: null,
      installs: "100k+ Installs"
    },
    tags: ["Gatsby", "Styled Components", "Netlify"],
    link: "https://halcyon-theme.com"
  },
  {
    id: 4,
    title: "brittanychiang.com (v4)",
    year: "",
    description: "An old portfolio site built with Gatsby and 6kx stars and 3k+ forks.",
    image: "/images/portfolio-v4.png",
    stats: {
      stars: "6,170",
      installs: null
    },
    tags: ["Gatsby", "Styled Components", "Netlify"],
    link: "https://v4.brittanychiang.com"
  }
];

/**
 * Archive Projects
 * List lengkap semua projects
 */
export const archiveProjects = [
  {
    id: 1,
    year: "2024",
    title: "5 Common Accessibility Pitfalls and How to Avoid Them",
    madeAt: "Upstatement",
    tags: ["Accessibility", "Web Development"],
    link: "https://upstatement.com/blog/accessibility-pitfalls"
  },
  {
    id: 2,
    year: "2020",
    title: "Integrating Algolia Search with WordPress Multisite",
    madeAt: "Upstatement",
    tags: ["Algolia", "WordPress", "PHP"],
    link: "https://upstatement.com/blog/algolia-wordpress"
  },
  {
    id: 3,
    year: "2019",
    title: "Building a Headless Mobile App CMS From Scratch",
    madeAt: "Upstatement",
    tags: ["Mobile", "CMS", "Headless"],
    link: "https://upstatement.com/blog/headless-cms"
  }
];

/**
 * Navigation Items
 * Untuk sidebar navigation
 */
export const navItems = [
  { id: 'about', label: 'ABOUT' },
  { id: 'experience', label: 'EXPERIENCE' },
  { id: 'projects', label: 'PROJECTS' }
];