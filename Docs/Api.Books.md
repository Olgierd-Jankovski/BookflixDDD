# Bookflix API

-[Bookflix API](#book-flix-api)
    -[Books](#books)
        -[Create Book](#create)
            -[Create Request](#create-request)
            -[Create Response](#create-response)
        -[Add Review](#addreview)
            -[Add Review Request](#addreview-request)
            -[Add Review Response](#addreview-response)
        -[List Books](#list)
            -[List Request](#list-request)
            -[List Response](#list-response)

## Books

### Create Book

```js
POST{{host}}/books
```

#### Create Request

```json
{
    "title": "string",
    "author": "string",
    "genre": [
        {
            "genreId": 0,
        }
    ],
    "year": 0,
    "description": "string"
}
```

#### Create Response

```js
200 OK
```

```json
{
    "id": 0,
    "authorId": 0,
    "title": "string",
    "description": "string",
    "averageRating": 0.0,
    "genres": [
        {
            "id": 0,
            "name": "string"
        }
    ],
    "reviews": [
        {
            "id": 0,
            "rating": 0,
            "comment": "string",
            "authorIdentityGuid": "string",
            "reviewerIdentityGuid": "string",
            "bookId": 0
        }
    ]
}
```

### Add Review

```js
POST{{host}}/books/{bookId}/reviews
```

#### Add Review Request

```json
{
    "rating": 0,
    "comment": "string",
    "bookId": 0
}
```

#### Add Review Response

```js
200 OK
```

```json
{
    "id": 0,
    "rating": 0,
    "comment": "string",
    "authorIdentityGuid": "string",
    "reviewerIdentityGuid": "string",
    "bookId": 0
}
```

### List Books

```js
GET{{host}}/books?genreId={genreId}
```

#### List Request

```json
{
}
```

#### List Response

```js
200 OK
```

```json
[
    {
        "id": 0,
        "authorId": 0,
        "title": "string",
        "description": "string",
        "averageRating": 0.0,
        "genres": [
            {
                "id": 0,
                "name": "string"
            }
        ],
        "reviews": [
            {
                "id": 0,
                "rating": 0,
                "comment": "string",
                "authorIdentityGuid": "string",
                "reviewerIdentityGuid": "string",
                "bookId": 0
            }
        ]
    }
]