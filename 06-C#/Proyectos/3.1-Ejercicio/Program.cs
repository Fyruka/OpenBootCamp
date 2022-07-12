Datos myCliente = new Datos("Samuel", 654987321, "Calle calle 34, 2º 3ª", "cliente@email.com", true);

Console.WriteLine(myCliente);

public struct Datos
{
    public Datos(string name, long phone, string address, string email, bool newClient)
    {
        Name = name;
        Phone = phone;
        Address = address;
        Email = email;
        NewClient = newClient;
    }

    public string Name { get; set; }
    public long Phone { get; set; }
    public string Address { get; set; }
    public string Email { get; set; }
    public bool NewClient { get; set; }

    public override string ToString() => $"Nombre: {Name}, Telefono: {Phone}, Direccion: {Address}, Email: {Email}, Nuevo cliente: {NewClient}";
}