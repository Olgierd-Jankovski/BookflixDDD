# Domain models

## Book

``` csharp
```

```json
{
    "id": "00000",
    "authorId": 11,
    "title": "The Best Book",
    "description": "This is the best book ever",
    "averageRating": 4.5,
    "genres":[
        {
            "id": 1,
            "genre": 1,
            "bookId": 00000
        },
        {
            "id": 2,
            "genre": 2,
            "bookId": 00000,
        }
    ],

    "createdDateTime": "2021-01-01T00:00:00",
    "updatedDateTime": "2021-01-01T00:00:00",

    "bookReviews": [
        {
            "id": 111,
            "bookId": 00000,
            "rating": 5.0,
            "authorIdentityGuid": "00000000-0000",
            "comment": "This is the best book ever",
        },
    ]

}
```