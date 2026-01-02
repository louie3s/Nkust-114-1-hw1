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

async function loadByCity(city) {

    if (!city) return;
    

    city = city.trim();

    const res = await fetch(`/api/Air/${encodeURIComponent(city)}`);
    const data = await res.json();

    const tbody = document.getElementById("result");
    tbody.innerHTML = "";

    data.forEach(x => {
        const tr = document.createElement("tr");

        tr.innerHTML = `
            <td>${x.sitename ?? "-"}</td>
            <td>${x.county ?? "-"}</td>
            <td>
                <span class="badge bg-warning text-dark">
                    ${x["pm2.5"] ?? "-"}
                </span>
            </td>
            <td>${x.publishtime}</td>
        `;


        tbody.appendChild(tr);
    });
    console.log(data);
}


function searchCity() {
    const city = document.getElementById("cityInput").value.trim();
    if (!city) {
        alert("請輸入縣市名稱");
        return;
    }
    loadByCity(city);
}

document.getElementById("cityInput")
    .addEventListener("keydown", function (e) {
        if (e.key === "Enter") {
            searchCity();
        }
    });
