# mongodb-webapi
An ultra simple example of using mongo database instead of SQL for a webapi.

# Async
Goto async branch to see my testing of making queries asynchronous. Unfortunately, it seems that although `getBooks()` works as intended, when I try `getBook(id)`, something breaks, and only `{"current": null}` returns. I will have to do more research to get everything to work. I believe it's an issue with the id property.
