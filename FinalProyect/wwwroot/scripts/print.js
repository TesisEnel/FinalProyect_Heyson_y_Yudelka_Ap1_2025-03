globalThis.printSection = function (elementoId) {
    const original = document.body.innerHTML;
    const section = document.getElementById(elementoId).innerHTML;

    document.body.innerHTML = `
        <div style="padding: 40px;">
            ${section}
        </div>
    `;

    globalThis.print();

    document.body.innerHTML = original;
    location.reload();
};
