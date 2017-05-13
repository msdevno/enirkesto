# Classify

```http
POST /models/:train/classify
```

## Route Parameters

| Name  | Type   | Description                     |
| ----- | ------ | ------------------------------- |
| model | string | The model type you're training. |

## Parameters

| Name        | Type   | Description                                          |
| ----------- | ------ | ---------------------------------------------------- |
| key         | string | Unique key for a container that will hold the model. |
| language    | string | Optional language key                                |
| text        | string | Text to classify                                     |

## Response

>The response will hold an array of classifications, sorted descending on score.
>The score indicates how well the classification fits.

```json
Status: 200 OK

[
    {
        "classification": "<NAME OF CLASSIFICATION>",
        "score": 0.5
    }
]
```

### Example

```http
POST /models/:train/classify
```

```json
{
    "key": "something",
    "language": "nb",
    "text": "Lava"
}
```

### Response

```json
[
  {
    "classification": "Hot",
    "score": 0.52368234432123122
  },
  {
    "classification": "Earth",
    "score": 0.20689655172413793
  }
]
````