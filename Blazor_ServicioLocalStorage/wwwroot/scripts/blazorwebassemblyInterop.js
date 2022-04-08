var blazorwebassemblyInterop = {};

blazorwebassemblyInterop.setLocalStorage = function (key, data) {
    localStorage.setItem(key, data);
}

blazorwebassemblyInterop.getLocalStorage = function (key) {
    return localStorage.getItem(key);
}
