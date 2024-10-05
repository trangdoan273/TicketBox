document.addEventListener('DOMContentLoaded', function () {
    const dateLinks = document.querySelectorAll('.date-link');

    dateLinks.forEach(link => {
        link.addEventListener('click', function () {

            dateLinks.forEach(l => l.classList.remove('active'));

            this.classList.add('active');
        });
    });
});