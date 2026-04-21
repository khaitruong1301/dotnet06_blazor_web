
window.sayHello = async (title,name) => {

    console.log(`
            Hello ${title}
            Hello ${name}
        `)

}


window.fetchDataApi = async () => {

   let response = await fetch("https://apistore.cybersoft.edu.vn/api/Product");

   let data = await response.json();

   console.log(data);
    


}




window.tinhTong = async (a,b) => {
    // console.log(`${a},${b}`);
    return a + b;

}

//Vercel (JS) => nextjs (server side rendering) (lai react)
//Microsoft (C#) => blazor server (server side rendering) -> Thuần C#




//Viết hàm lấy danh sách sản phẩm từ api getAllProduct

let getAllProductApi = async () => {

    let response = await fetch("https://apistore.cybersoft.edu.vn/api/Product");
    let data = await response.json();
    console.log(data);
    //JS DOM 
    let strHTML = "";
    for(let item of data.content){
        strHTML += `<div class="col-md-3 mt-2">
            <div class="card">
                <img src="${item.image}" alt="${item.alias}" />
                <div class="card-body">
                    <h3 class="card-title">${item.name} </h3>
                    <p class="card-text">${item.price}</div>
                    <button class="btn btn-dark">Detail</button>
                </div>
            </div>
        </div>
        `;
    }
    document.querySelector('#content').innerHTML += strHTML;
}
// getAllProductApi();


//Application js 

/*
    localstorage: Lưu được 5mb tại client và lưu dạng key value
    .getItem('key'): lấy ra dữ liệu value từ localstorage dựa vào key
    .setItem('key'): Gán giá trị vào localstorage dựa vào key
    .removeItem('key'): Xoá giá trị localstorage dựa vào key
*/



window.setLocalstorage = () => {
    localStorage.setItem("data","data 123");

    let prod =  {
        id:1,
        name:'Iphone',
        price: 1000
    }

    //primitive value: string, boolean,number 
    localStorage.setItem('data object',JSON.stringify(prod));
    /*
        json -> string : JSON.stringify <=>  JsonSerializer.Serialize()
        string -> json: JSON.parse <=> JsonSerializer.Deserialize<T>    
    */
}




window.getStorage = () => {
    let sData = localStorage.getItem('data');
    console.log(sData)

    //Lấy json data 
    let sJSON = localStorage.getItem('data object');
    console.log(sJSON);
    let json = JSON.parse(sJSON);
    console.log(json);
    console.log(json.id);
    console.log(json.name);
    console.log(json.price);
}

window.removeStorage = () => {
    localStorage.removeItem('data');
}




//Tạo các hàm get set remove cookie
export function setCookie(name, value, days) {
    const expires = new Date(Date.now() + days * 24 * 60 * 60 * 1000).toUTCString();
    document.cookie = `${name}=${value}; expires=${expires}; path=/`;
}

export function getCookie(name) {
    const cookies = document.cookie.split(';');
    for (let cookie of cookies) {
        const [cookieName, cookieValue] = cookie.trim().split('=');
        if (cookieName === name) {
            return cookieValue;
        }
    }
    return null;
}

export function removeCookie(name) {
    setCookie(name, '', -1);
}

setCookie('accessToken','ABCCybersoft123',30);




