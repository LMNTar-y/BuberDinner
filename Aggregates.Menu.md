# Domain Models

## Menu

```csharp
class Menu
{
	Menu Create();
	void Adddinner(Dinner dinner);
	void RemoveDinner(Dinner dinner);
	void UpdateSection(MenuSection section);
}
```

```json
{
  "id": "00000000-000-000-000-000000000001",
  "name": "Yummy Menu",
  "description": "This is a yummy menu",
  "averageRating": 4.5,
  "sections" : [
	{
	  "id": "00000000-000-000-000-000000000001",
	  "name": "Main Course",
	  "description": "This is a yummy main course","
	  "items": [
		{
		  "id": "00000000-000-000-000-000000000001",
		  "name": "Chicken Curry",
		  "description": "This is a yummy chicken curry",
		  "price": 10.00
		},
		{
		  "id": "00000000-000-000-000-000000000002",
		  "name": "Beef Curry",
		  "description": "This is a yummy beef curry",
		  "price": 12.00
		}
	  ]
	}
  ],
  "createdDateTime": "2020-01-01T00:00:00Z",
  "updatedDateTime": "2020-01-01T00:00:00Z"
  "hostId": "00000000-000-000-000-000000000001",
  "dinnerIds": [
	"00000000-000-000-000-000000000001",
	"00000000-000-000-000-000000000002"
  ],
  "menuRewardIds" : [
  "00000000-000-000-000-000000000001"
  ]
}
```