let pending = document.querySelector(".title-pending");
let pendingList = document.getElementById("list-pending");
let done = document.querySelector(".title-done");
let doneList = document.getElementById("list-done");
let cancelled = document.querySelector(".title-cancelled");
let cancelledList = document.getElementById("list-cancelled");
let show = document.querySelectorAll(".show")
let hide = document.querySelectorAll(".hide")
let title = document.querySelector(".title")
const saveButton = document.getElementById("todo-button");

// İşlem başlıklarına tıklandığında açılıp kapanmaları
pending.addEventListener("click", () => { pendingList.classList.toggle("display-none"); hide[0].classList.toggle("display-none"); show[0].classList.toggle("display-none"); });
done.addEventListener("click", () => { doneList.classList.toggle("display-none"); hide[1].classList.toggle("display-none"); show[1].classList.toggle("display-none"); });
cancelled.addEventListener("click", () => { cancelledList.classList.toggle("display-none"); hide[2].classList.toggle("display-none"); show[2].classList.toggle("display-none"); });

// Yeni girdi yapıldığında pending bölümüne eklenmesi
const saveWork = () => {
    let textDOM = document.getElementById("todo-text")
    text = textDOM.value

    // Text boş ise hata verilmesi
    if (text == "" || text.replace(/^\s+|\s+$/g, "").length == 0) {
        title.innerHTML = "Text cannot be empty"
        title.style.color = "#fa560f"
        setTimeout(() => { title.innerHTML = "To Do List"; title.style.color = "white" }, 1500)
    }
    // İş zaten varsa hata verilmesi
    else if(isExist(text)){
        title.innerHTML = "Work already exist"
        title.style.color = "#fa560f"
        setTimeout(() => { title.innerHTML = "To Do List"; title.style.color = "white" }, 1500)
    }
    else {
        let li = document.createElement("li");
        li.innerHTML = `
        <div class="li-text">${text}</div>
        <div class="li-buttons">
            <button class="btn btn-success done-button" onclick="makeDone(this)"><i class="fas fa-check"></i></button>
            <button class="btn btn-danger cancel-button" onclick="makeCancel(this)"><i class="fas fa-times"></i></button>
            <button class="cancel-button btn btn-secondary" onclick="updateText(this)"><i class="fas fa-pen"></i></button>
            <button class="info-button btn btn-info" onclick="showInfo(this)"><i class="fas fa-info"></i></button>
        </div>`;
        pendingList.append(li);
        let obj = { "createdAt": new Date(), "process": "pending" };
        localStorage.setItem(text, JSON.stringify(obj))

    }
    textDOM.value = "";
}

// İşin Done başlığı altına eklenmesi
const makeDone = (doneButton) => {
    let li = document.createElement("li");
    // Yapıldı butonuna tıklandığında burası çalışır
    if (typeof doneButton == "object") {
        let textToDone = doneButton.parentElement.parentElement.childNodes[1].innerText;
        doneButton.parentElement.parentElement.remove()

        li.innerHTML = `
        <div class="li-text">${textToDone}</div>
        <div class="li-buttons">
            <button class="btn btn-warning text-white" onclick="makePending(this)"><i class="fas fa-hourglass-half"></i></button>
            <button class="cancel-button btn btn-danger" onclick="makeCancel(this)"><i class="fas fa-times"></i></button>
            <button class="cancel-button btn btn-secondary" onclick="updateText(this)"><i class="fas fa-pen"></i></button>
            <button class="info-button btn btn-info" onclick="showInfo(this)"><i class="fas fa-info"></i></button>
        </div>`;
        doneList.append(li);

        let localValue = JSON.parse(localStorage.getItem(textToDone))
        let obj = { "createdAt": localValue.createdAt, "updatedAt": new Date(), "process": "done" }
        localStorage.setItem(textToDone, JSON.stringify(obj))
    }
    // Sayfa yenilendiğinde localstorage'dan doldurulacağında burası çalışır
    else if (typeof doneButton == "string") {
        li.innerHTML = `
        <div class="li-text">${doneButton}</div>
        <div class="li-buttons">
            <button class="btn btn-warning text-white" onclick="makePending(this)"><i class="fas fa-hourglass-half"></i></button>
            <button class="cancel-button btn btn-danger" onclick="makeCancel(this)"><i class="fas fa-times"></i></button>
            <button class="cancel-button btn btn-secondary" onclick="updateText(this)"><i class="fas fa-pen"></i></button>
            <button class="info-button btn btn-info" onclick="showInfo(this)"><i class="fas fa-info"></i></button>
        </div>`;
        doneList.append(li);
    }

}

// İşin Cancelled başlığı altına eklenmesi
const makeCancel = (cancelButton) => {
    let li = document.createElement("li");
    // Cancel butonuna tıklandığında burası çalışır
    if (typeof cancelButton == "object") {
        let textToCancel = cancelButton.parentElement.parentElement.childNodes[1].innerText;
        cancelButton.parentElement.parentElement.remove()

        li.innerHTML = `
        <div class="li-text">${textToCancel}</div>
        <div class="li-buttons">
            <button class="cancel-button btn btn-success" onclick="makeDone(this)"><i class="fas fa-check"></i></button>
            <button class="btn btn-warning pending-button text-white" onclick="makePending(this)"><i class="fas fa-hourglass-half"></i></button>
            <button class="cancel-button btn btn-secondary" onclick="updateText(this)"><i class="fas fa-pen"></i></button>
            <button class="info-button btn btn-info" onclick="showInfo(this)"><i class="fas fa-info"></i></button>
        </div>`;
        cancelledList.append(li);

        let localValue = JSON.parse(localStorage.getItem(textToCancel))
        let obj = { "createdAt": localValue.createdAt, "updatedAt": new Date(), "process": "cancelled" }
        localStorage.setItem(textToCancel, JSON.stringify(obj))
    }
    // Sayfa yenilendiğinde localstorage'dan doldurulacağında burası çalışır
    else if (typeof cancelButton == "string") {
        li.innerHTML = `
        <div class="li-text">${cancelButton}</div>
        <div class="li-buttons">
            <button class="cancel-button btn btn-success" onclick="makeDone(this)"><i class="fas fa-check"></i></button>
            <button class="btn btn-warning pending-button text-white" onclick="makePending(this)"><i class="fas fa-hourglass-half"></i></button>
            <button class="cancel-button btn btn-secondary" onclick="updateText(this)"><i class="fas fa-pen"></i></button>
            <button class="info-button btn btn-info" onclick="showInfo(this)"><i class="fas fa-info"></i></button>
        </div>`;
        cancelledList.append(li);
    }

}

// İşin Pending başlığı altına eklenmesi
const makePending = (pendingButton) => {
    let li = document.createElement("li");
    // Bekleme butonuna tıklandığında burası çalışır
    if (typeof pendingButton == "object") {
        let textToPending = pendingButton.parentElement.parentElement.childNodes[1].innerText;
        pendingButton.parentElement.parentElement.remove()


        li.innerHTML = `
        <div class="li-text">${textToPending}</div>
        <div class="li-buttons">
            <button class="btn btn-success done-button" onclick="makeDone(this)"><i class="fas fa-check"></i></button>
            <button class="cancel-button btn btn-danger" onclick="makeCancel(this)"><i class="fas fa-times"></i></button>
            <button class="cancel-button btn btn-secondary" onclick="updateText(this)"><i class="fas fa-pen"></i></button>
            <button class="info-button btn btn-info" onclick="showInfo(this)"><i class="fas fa-info"></i></button>
        </div>`;
        pendingList.append(li);

        let localValue = JSON.parse(localStorage.getItem(textToPending))
        let obj = { "createdAt": localValue.createdAt, "updatedAt": new Date(), "process": "pending" }
        localStorage.setItem(textToPending, JSON.stringify(obj))
    }
    // Sayfa yenilendiğinde localstorage'dan doldurulacağında burası çalışır
    else if (typeof pendingButton == "string") {
        li.innerHTML = `
        <div class="li-text">${pendingButton}</div>
        <div class="li-buttons">
            <button class="btn btn-success done-button" onclick="makeDone(this)"><i class="fas fa-check"></i></button>
            <button class="cancel-button btn btn-danger" onclick="makeCancel(this)"><i class="fas fa-times"></i></button>
            <button class="cancel-button btn btn-secondary" onclick="updateText(this)"><i class="fas fa-pen"></i></button>
            <button class="info-button btn btn-info" onclick="showInfo(this)"><i class="fas fa-info"></i></button>
        </div>`;
        pendingList.append(li);
    }
}

// Update butonuna tıklandığında textin güncellenmesi ve local storage a kaydedilmesi
const updateText = (updateButton) => {
    let text = updateButton.parentElement.parentElement.childNodes[1].innerText;
    let newText = prompt("New Text ?");
    // Text'in localstorage'da olup olmadığının kontrolü
    if(isExist(newText)){
        alert("Work already exist")
        setTimeout(() => { alert }, 1500)
    }
    else {
        updateButton.parentElement.parentElement.childNodes[1].innerText = newText;
        let oldKeyData = localStorage.getItem(text)
        localStorage.setItem(newText, oldKeyData)

        localStorage.removeItem(text)
    }

}

// Info butonuna tıklandığında alertte işin, oluşturulma tarihinin, son değiştirme tarihinin ve durumunun gösterilmesi
const showInfo = (infoButton) => {
    let text = infoButton.parentElement.parentElement.childNodes[1].innerText;
    let data = JSON.parse(localStorage.getItem(text))
    alert(
        `
        Text: ${text}
        Created at: ${data.createdAt}
        Last update: ${data.updatedAt}
        Process: ${data.process}`
    )
}

// İşin olup olmadığını kontrol eden fonksiyon
const isExist = (textToControl) => localStorage.getItem(textToControl) ? true : false;

    

// Sayfa yenilendiğinde localstorage'dan sayfanın doldurulması
(() => {
    let keys = Object.keys(localStorage)
    keys.forEach(item => {
        let key = JSON.parse(localStorage.getItem(item))
        // Objelerin process keylerine göre gerekli başlıklar altına eklenmesi
        key.process == "done" ? makeDone(item) : key.process == "cancelled" ? makeCancel(item) : makePending(item)
    })
})();

