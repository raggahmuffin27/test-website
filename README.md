# Billing Manager System

A comprehensive billing management system for property management companies, designed to handle water, electricity, and monthly dues billing for residential buildings.

## Features

### Core Functionality
- **Property Management**: Buildings, floors, and units hierarchy
- **Customer Management**: Homeowner and tenant information
- **Billing System**: Automated monthly billing for utilities and dues
- **Payment Processing**: Multiple payment methods and collection tracking
- **Penalty Management**: Automatic penalty calculation for overdue bills
- **Statement of Account**: Comprehensive billing history and outstanding balances
- **Advanced Payments**: Outstanding balance management for prepayments

### Billing Types
1. **Water Bills**: Based on consumption data uploaded via Excel
2. **Electricity Bills**: Based on consumption data uploaded via Excel  
3. **Monthly Dues**: Calculated as Rate × Floor Area per unit

### Key Features
- Excel import/export functionality for utility readings
- Automated penalty calculation for late payments
- Multi-bill payment processing
- Outstanding balance tracking for advance payments
- Comprehensive reporting with RDLC
- Statement of Account generation

## Technical Stack

- **.NET 8**: Latest version of .NET
- **Entity Framework Core**: Database ORM
- **SQL Server**: Database engine
- **Blazor Server**: Web UI framework
- **Radzen Components**: UI component library
- **RDLC Reports**: Report generation
- **Vertical Slice Architecture**: Clean architecture pattern
- **Repository Pattern**: Data access abstraction

## Project Structure

```
src/
├── BillingManager.Domain/          # Domain entities and business logic
│   ├── Common/                     # Base entities and interfaces
│   ├── Entities/                   # Domain entities
│   ├── Enums/                      # Domain enumerations
│   └── ValueObjects/               # Value objects
├── BillingManager.Application/     # Application layer
│   ├── Interfaces/                 # Repository and service interfaces
│   ├── Features/                   # Vertical slice features
│   └── Common/                     # Shared application logic
├── BillingManager.Infrastructure/  # Infrastructure layer
│   ├── Data/                       # Database context
│   ├── Repositories/               # Repository implementations
│   └── Configurations/             # Entity configurations
└── BillingManager.Web/             # Blazor web application
    ├── Pages/                      # Razor pages
    ├── Shared/                     # Shared components
    └── wwwroot/                    # Static files
```

## Domain Model

### Core Entities

#### Property Hierarchy
- **Building**: Represents a building complex
- **Floor**: Individual floors within a building
- **Unit**: Individual units/apartments with floor area and monthly dues rate

#### Customer Management
- **Customer**: Homeowner/tenant information with outstanding balance tracking

#### Billing System
- **Bill**: Individual bills with consumption data, amounts, and payment tracking
- **Payment**: Payment records with multiple bill support
- **PaymentBill**: Junction entity for multi-bill payments
- **PaymentMode**: Payment method configuration

#### Rate Management
- **WaterRate**: Water billing rates per cubic meter
- **ElectricityRate**: Electricity billing rates per kWh
- **PenaltyRate**: Penalty calculation rules

## Database Schema

The system uses Entity Framework Code First approach with the following key relationships:

- Buildings → Floors → Units (Hierarchical)
- Customers ↔ Units (One-to-Many)
- Customers → Bills (One-to-Many)
- Bills ↔ Payments (Many-to-Many via PaymentBill)
- Payments → PaymentMode (Many-to-One)

## Getting Started

### Prerequisites
- .NET 8 SDK
- SQL Server (LocalDB or full instance)
- Visual Studio 2022 or VS Code

### Setup Instructions

1. **Clone the repository**
   ```bash
   git clone <repository-url>
   cd billing-manager
   ```

2. **Update connection string**
   Edit `src/BillingManager.Web/appsettings.json`:
   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=BillingManagerDb;Trusted_Connection=true;MultipleActiveResultSets=true"
     }
   }
   ```

3. **Build the solution**
   ```bash
   dotnet build
   ```

4. **Run the application**
   ```bash
   cd src/BillingManager.Web
   dotnet run
   ```

5. **Access the application**
   Open your browser and navigate to `https://localhost:5001`

## Key Business Rules

### Monthly Dues Calculation
```
Monthly Dues = Rate × Floor Area
```

### Penalty Calculation
- Applied to overdue bills based on configured penalty rates
- Grace period support before penalties apply
- Can be percentage-based or fixed amount

### Outstanding Balance Management
- Advance payments stored as outstanding balance
- Automatically applied to future bills during collection
- Tracked per customer across all units

### Multi-Bill Payment Processing
- Single payment can cover multiple outstanding bills
- Partial payment support with remaining balance tracking
- Payment allocation across bills with detailed tracking

## Development Guidelines

### Architecture Patterns
- **Vertical Slice Architecture**: Features organized by business capability
- **Repository Pattern**: Data access abstraction
- **CQRS**: Command Query Responsibility Segregation for complex operations

### Code Organization
- Domain entities contain business logic and rules
- Application layer handles use cases and orchestration
- Infrastructure layer manages data persistence and external services
- Web layer provides user interface and API endpoints

## Future Enhancements

- [ ] Mobile application support
- [ ] Email notifications for due bills
- [ ] SMS integration for payment reminders
- [ ] Dashboard analytics and reporting
- [ ] Bulk operations for bill generation
- [ ] Integration with accounting systems
- [ ] Multi-tenant support for property management companies

## Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests for new functionality
5. Submit a pull request

## License

This project is licensed under the MIT License - see the LICENSE file for details.

