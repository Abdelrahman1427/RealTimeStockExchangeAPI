# RealTimeStockExchange Application

## Backend API Guide

### Running the Backend (RealTimeStockExchangeAPI)
1. Press Ctrl+F5 to run the app.

### Authentication
1. **POST /api/Auth/login**
   - In the Swagger browser window, select POST /api/Auth/login, and then click on "Try it out."
   - Enter the following credentials in the Request body:
     ```json
     { "UserName": "egid", "Password": "egid" }
     ```
   - Click "Execute" to get the token.

### Order Operations
2. **POST /API/orders**
   - Select POST /API/orders and click "Try it out."
   - Enter the order details in the Request body:
     ```json
     { "StockSymbol": "string", "OrderType": "string", "Quantity": number }
     ```
   - Click "Execute." The response body should show "Order created successfully."

3. **GET /API/orders**
   - Select GET /API/orders and click "Try it out."
   - Click "Execute." The response body should display a list of ordered items (Stock Symbol, Order Type, Quantity).

### Stock Operations
4. **GET /api/Stock**
   - Select GET /api/Stock and click "Try it out."
   - Click "Execute." The response body should display a list of Stock items (Symbol, Current Price, TimeStamps).

5. **GET /api/Stock/{symbol}/history**
   - Select GET /api/Stock/{symbol}/history and click "Try it out."
   - Enter the symbol in the Parameters section.
   - Click "Execute." The response body should display the history of the specified symbol.

**Note:**
- All live data comes from [IEX Cloud](https://api.iex.cloud/v1/data/).

## Frontend Angular Guide

### Frontend ([https://github.com/Abdelrahman1427/RealTimeStockExchangeUI/]).


