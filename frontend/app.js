window.addEventListener("DOMContentLoaded", () => {

    const productsContainer = document.querySelector(".productsContainer");
    const urn_Btn = document.querySelector(".urnBtn");
    const ogr_Btn = document.querySelector(".ogrBtn");

    let btnUrn = "click";
    let btnOgr = "click";

    function userinfoalertF() {
        let alertforUser = "Evertyhing is Not Good!";
        window.alert(alertforUser);
    }

    function userinfoalertT() {
        let alertforUser = "Evertyhing is Good!";
        window.alert(alertforUser);
    }

    urn_Btn.addEventListener(btnUrn, getProducts);
    function getProducts(e) {
        try {
            userinfoalertT();
            productsContainer.innerHTML = "";
            getProduct();
            e.preventDefault()
        } catch (error) {
            userinfoalertF();
        }

    }

    ogr_Btn.addEventListener(btnOgr, GetStudent);
    function GetStudent(e) {
        try {
            userinfoalertT();
            productsContainer.innerHTML = "";
            GetStudents();
        } catch (error) {
            userinfoalertF();
        }

    }

    async function GetStudents() {
        try {
            let res = await fetch("https://localhost:7218/ogrenciler");
            let data = await res.json();

            data.forEach(element => {
                const { id, name } = element;

                productsContainer.innerHTML +=
                    `
                     <span><br>Öğrenciler:${name}</span>
                    `;
            });
        } catch (error) {
            window.alert("We Have A Problem");
            console.log("We Have A Problem!");
        }
    }

    async function getProduct() {
        try {
            let res = await fetch("https://localhost:7218/Urunler");
            let data = await res.json();


            data.forEach(element => {
                const { id, name } = element;

                productsContainer.innerHTML +=
                    `
                <span><br>Ürünler: ${name}</span>
                `;
            });

        } catch (error) {
            window.alert("We Have A Problem");
            console.log("We Have A Problem!");
        }

    }

  

});