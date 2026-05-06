using Microsoft.AspNetCore.SignalR;

public class RoomHub : Hub
{
    public static List<RoomViewModel> lstRoom = new List<RoomViewModel>();
    static RoomHub()
    {
        for(int i=0; i < 5; i++)
        {
            RoomViewModel room = new RoomViewModel();
            lstRoom.Add(room);
        }
    }

    public override async Task OnConnectedAsync()
    {
        // Console.WriteLine($"[SignalR] Connected: {Context.ConnectionId}");
        await base.OnConnectedAsync();
        Console.WriteLine($@"client - {Context.ConnectionId}");

        //Server gửi 10 cái room cho tất cả signalr client 
        await Clients.All.SendAsync("getAllRoom", lstRoom);

    }

    public async Task addRoom(string abc)
    {
        Console.WriteLine($@"add room");
        RoomViewModel room = new RoomViewModel();
        lstRoom.Add(room);
        //Sau khi add sẽ phát lại lst room mới trên message getAllRoom
        await Clients.All.SendAsync("getAllRoom", lstRoom);

    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine($"[SignalR] Disconnected: {Context.ConnectionId}");
        await base.OnDisconnectedAsync(exception);
    }
}