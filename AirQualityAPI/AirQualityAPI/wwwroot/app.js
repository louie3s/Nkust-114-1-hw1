async function loadTop(count) {
    const res = await fetch(`/api/Air/top/${count}`);
    const data = await res.json();

    const tbody = document.getElementById("result");
    tbody.innerHTML = "";

    data.forEach(x => {
        const tr = document.createElement("tr");

        tr.innerHTML = `
            <td>${x.siteName ?? "-"}</td>
            <td>${x.county ?? "-"}</td>
            <td>
                <span class="badge bg-warning text-dark">
                    ${x.pM25}
                </span>
            </td>
            <td>${x.publishTime}</td>
        `;

        tbody.appendChild(tr);
    });
}
