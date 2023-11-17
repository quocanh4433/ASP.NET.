document.querySelector("#button-load").addEventListener("click", async () => {
    let response = await fetch("friend-list", { method: "GET" })
    let friends = await response.text()
    document.querySelector("#list").innerHTML = friends
});