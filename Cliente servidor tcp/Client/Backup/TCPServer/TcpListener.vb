Imports System.Net.Sockets
Imports System.Text
Class TCPSrv
    Shared Sub Main()
        ' Must listen on correct port- must be same as port client wants to connect on.
        Const portNumber As Integer = 8000
        Dim tcpListener As New TcpListener(portNumber)
        tcpListener.Start()
        Console.WriteLine("Waiting for connection...")
        Try
            'Accept the pending client connection and return a TcpClient initialized for communication. 
            Dim tcpClient As TcpClient = tcpListener.AcceptTcpClient()
            Console.WriteLine("Connection accepted.")
            ' Get the stream
            Dim networkStream As NetworkStream = tcpClient.GetStream()
            ' Read the stream into a byte array
            Dim bytes(tcpClient.ReceiveBufferSize) As Byte
            networkStream.Read(bytes, 0, CInt(tcpClient.ReceiveBufferSize))
            ' Return the data received from the client to the console.
            Dim clientdata As String = Encoding.ASCII.GetString(bytes)
            Console.WriteLine(("Client sent: " + clientdata))
            Dim responseString As String = "Connected to server."
            Dim sendBytes As [Byte]() = Encoding.ASCII.GetBytes(responseString)
            networkStream.Write(sendBytes, 0, sendBytes.Length)
            Console.WriteLine(("Message Sent /> : " + responseString))
            'Any communication with the remote client using the TcpClient can go here.
            'Close TcpListener and TcpClient.
            tcpClient.Close()
            tcpListener.Stop()
            Console.WriteLine("exit")
            Console.ReadLine()
        Catch e As Exception
            Console.WriteLine(e.ToString())
            Console.ReadLine()
        End Try
    End Sub
End Class
