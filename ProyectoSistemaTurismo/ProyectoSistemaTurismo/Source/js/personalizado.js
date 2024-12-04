
// Alertas Mensaje o Error
setTimeout(function () {
    const alerts = document.querySelectorAll('.alert-floating');
    alerts.forEach(alert => {
        alert.classList.add('fade-out');
        setTimeout(() => alert.remove(), 500);
    });
}, 5000); // Tiempo de 5 segundos
