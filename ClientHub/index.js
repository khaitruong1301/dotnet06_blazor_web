console.log("first");
//fetch hoặc axios (http) 


//signalClient


//trang html load xong tự gọi hàm này
const connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:5210/roomhubs").withAutomaticReconnect().build();


window.handleAddRoom = async () => {
   await connection.invoke("addRoom");

}

//Chứa hàm kết nối khi web được mở
window.onload = async function () {


    try {
        await connection.start();
        console.log("kết nối thành công");
        //Luôn lắng nghe khi server có sự kiện phát đi tên getAllRoom
        connection.on("getAllRoom", async (lstRoom) => {
            console.log(lstRoom);
            //Cập nhật lại room giao diện
            let html = "";
            for (let room of lstRoom) {
                html += `
                    <div class="alert alert-success">
                        Room ${room.id}
                    </div>
                `
            }
            document.querySelector("#rooms-list").innerHTML = html;
        });
    } catch (err) {
        console.log(err)
    }
}









