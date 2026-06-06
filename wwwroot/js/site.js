(() => {
    const pageSize = 8;

    const normalize = (value) => (value || "").toString().toLowerCase().normalize("NFD").replace(/[\u0300-\u036f]/g, "");

    const getRows = (table) => Array.from(table.querySelectorAll("tbody tr"));

    const applyTableState = (table) => {
        const queryInput = document.querySelector(`[data-table-search="#${table.id}"]`);
        const filterInput = document.querySelector(`[data-table-filter="#${table.id}"]`);
        const query = normalize(queryInput?.value);
        const filterValue = normalize(filterInput?.value);
        const filterColumn = Number(filterInput?.dataset.filterColumn || -1);

        const rows = getRows(table);
        const matchedRows = rows.filter((row) => {
            const textMatch = normalize(row.innerText).includes(query);
            const filterMatch = filterColumn < 0 || !filterValue || normalize(row.children[filterColumn]?.innerText).includes(filterValue);
            return textMatch && filterMatch;
        });

        rows.forEach((row) => {
            row.dataset.matches = matchedRows.includes(row) ? "true" : "false";
            row.hidden = true;
        });

        renderPagination(table, matchedRows);
    };

    const renderPagination = (table, rows, activePage = 1) => {
        const shell = table.closest(".page-container")?.querySelector(".pagination-shell");
        const totalPages = Math.max(1, Math.ceil(rows.length / pageSize));
        const page = Math.min(activePage, totalPages);

        rows.forEach((row, index) => {
            row.hidden = index < (page - 1) * pageSize || index >= page * pageSize;
        });

        if (!shell) return;
        shell.innerHTML = "";

        if (rows.length <= pageSize) return;

        for (let i = 1; i <= totalPages; i += 1) {
            const button = document.createElement("button");
            button.type = "button";
            button.className = `pagination-button${i === page ? " active" : ""}`;
            button.textContent = i;
            button.addEventListener("click", () => renderPagination(table, rows, i));
            shell.appendChild(button);
        }
    };

    document.querySelectorAll("[data-table-search]").forEach((input) => {
        const table = document.querySelector(input.dataset.tableSearch);
        if (!table) return;
        input.addEventListener("input", () => applyTableState(table));
    });

    document.querySelectorAll("[data-table-filter]").forEach((input) => {
        const table = document.querySelector(input.dataset.tableFilter);
        if (!table) return;
        input.addEventListener("change", () => applyTableState(table));
    });

    document.querySelectorAll("table[id]").forEach(applyTableState);
})();
