# Train

```http
PUT /models/:model/train
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
| text        | string | Text to train with                                   |
| classifiers | array  | Array of strings holding the associated classifiers  |

>If you want to hold a general container and not a specific container. You could
>then use a general key that makes it reused.
>
>All models are stored in the `Models` folder where the key represents the sub >folder within it. The filename consists of the model type combined with the >language. This gives you an opportunity to have shared models, but also specific >models for a particular user, tenant or similar.
>
>The optional language key represents a [ISO 639-1](https://en.wikipedia.org/wiki/List_of_ISO_639-1_codes) code.
>If this is not given, the system will try to resolve the language from the text given.

## Response

```json
Status: 200 OK
---
{}
```

### Example

```http
PUT /models/tags/train
```

```json
{
    "key": "",
    "language": "",
    "text": "",
    "classifiers": ,
}
```
