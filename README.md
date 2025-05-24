# aspnet-param-binding

A project to explore parameter binding in ASP.NET.

## Explore nullable and required attribute

The following sections explore how ASP.NET Core handles nullable and required attributes in parameter binding across
- minimal APIs (which use the RequestDelegateFramework (RDF))
- minimal APIs with AoT (which use the RequestDelegateGenerator (RDG))
- controllers

These results are based on ASP.NET Core 9.0, specifically `9.0.300`.

## Minimal APIs
| param type | nullable | required | openapi | omitted | empty |
| ---------- | -------- | -------- | ------- | ------- | ----- |
| value      | No       | No       | required | 400 Bad Request | 400 Bad Request |
| value      | No       | Yes      | required | 400 Bad Request | 400 Bad Request |
| value      | Yes      | No       |         | null | 400 Bad Request |
| value      | Yes      | Yes      | required | null | 400 Bad Request |
| reference  | No       | No       | required | 400 Bad Request | "" |
| reference  | No       | Yes      | required | 400 Bad Request | "" |
| reference  | Yes      | No       |         | null    | ""     |
| reference  | Yes      | Yes      | required | null    | "" |

## Minimal APIs with AoT
| param type | nullable | required | openapi  | omitted | empty |
| ---------- | -------- | -------- | -------- | ------- | ----- |
| value      | No       | No       | required | 400 Bad Request | 0 |
| value      | No       | Yes      | required | 400 Bad Request | 0 |
| value      | Yes      | No       |          | null | null |
| value      | Yes      | Yes      | required | null | null |
| reference  | No       | No       | required | 400 Bad Request | "" |
| reference  | No       | Yes      | required | 400 Bad Request | "" |
| reference  | Yes      | No       |          | null | "" |
| reference  | Yes      | Yes      | required | null | "" |

## Controllers
| param type | nullable | required | openapi  | omitted | empty |
| ---------- | -------- | -------- | -------- | ------- | ----- |
| value      | No       | No       |          | 0 | 400 Bad Request |
| value      | No       | Yes      | required | 400 Bad Request | 400 Bad Request |
| value      | Yes      | No       |          | null | null |
| value      | Yes      | Yes      | required | 400 Bad Request | 400 Bad Request |
| reference  | No       | No       |          | 400 Bad Request | 400 Bad Request |
| reference  | No       | Yes      | required | 400 Bad Request | 400 Bad Request |
| reference  | Yes      | No       |          | null | null |
| reference  | Yes      | Yes      | required | 400 Bad Request | 400 Bad Request |
