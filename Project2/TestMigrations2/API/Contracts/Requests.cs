namespace API.Contracts;

// A User is created together with its UserInformation (Egn + Address).
public record CreateUserRequest(string Email, string Region, string PhoneNumber, string Egn, string Address);

public record UpdateUserRequest(string Email, string Region, string PhoneNumber);

public record UpdateUserInformationRequest(string Egn, string Address);

public record CreateProductRequest(string Name, double Number, string Description);

public record UpdateProductRequest(string Name, double Number, string Description);

// An Order attaches an existing user (UserId) and existing products (ProductIds).
public record CreateOrderRequest(decimal Price, DateOnly ShippingDate, int UserId, List<int> ProductIds);

public record UpdateOrderRequest(decimal Price, DateOnly ShippingDate);
