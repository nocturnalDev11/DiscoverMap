## File Structure for DiscoverMap.Server:
```
DiscoverMap.Server/
│
├── Common/
│   ├── Helpers/
│   │   └── PasswordHasher.cs
│   ├── Middleware/
│   └── Extensions/
│
├── Configurations/
│	├── CorsConfigurations.cs
│	└── StaticFilesExtensions.cs
│
├── Data/
│	├── Seeders/
│	│   └── PinSeeder.cs
│	└── AppDbContext.cs
│
├── Extensions/
│	└── ServiceExtensions.cs
│
├── Features/
│   ├── Auth/
│   │   ├── Controllers/
│   │   │   └── AuthController.cs
│   │   ├── DTOs/
│   │   │   ├── LoginDTO.cs
│   │   │   └── RegisterDTO.cs
│   │   ├── Services/
│   │   │   └── AuthService.cs
│   │   ├── Repositories/
│   │   │   ├── IUserRepository.cs
│   │   │   └── UserRepository.cs
│   │   ├── Models/
│   │   │   └── User.cs
│   │   └── Mappings/
│   │       └── UserMapping.cs (optional later)
│   │
│   ├── Pins/
│   │   ├── Controllers/
│   │   │   └── PinController.cs
│   │   ├── DTOs/
│   │   │   └── CreatePinDTO.cs
│   │   ├── Services/
│   │   │   └── PinService.cs
│   │   ├── Repositories/
│   │   │   ├── IPinRepository.cs
│   │   │   └── PinRepository.cs
│   └───└── Models/
│           └── Pin.cs──
│
├── Routes/
│   ├── AuthRoutes.cs
│   └── PinRoutes.cs
│
└── Program.cs
```
