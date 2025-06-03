window.scrollToElement = function (elementId) {
    const element = document.getElementById(elementId);
    if (element) {
        element.scrollIntoView({ behavior: "smooth", block: "start" });
    }
};

window.toggleScrollTopButton = function () {
    const btn = document.getElementById("scrollTopBtn");
    if (!btn) return;

    const scrollCheck = () => {
        btn.style.display = window.scrollY > 100 ? "block" : "none";
    };

    window.removeEventListener('scroll', scrollCheck);
    window.addEventListener('scroll', scrollCheck);
    scrollCheck(); // langsung cek posisi scroll saat itu juga
};