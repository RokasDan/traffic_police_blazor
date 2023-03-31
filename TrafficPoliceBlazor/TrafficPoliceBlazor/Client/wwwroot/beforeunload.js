function beforeUnloadHandler() {
    localStorage.removeItem('username');
}

window.addEventListener('beforeunload', beforeUnloadHandler);