# QualifiedIO-WordCompletion-Test

Task
Overview

For this challenge, you'll be implementing a simple server application that offers basic word completion.

The server should offer one route, GET /, which can accept a query string stem that enables the client to specify the prefix of the words they'd like to retrieve. For example, given the following miniature word list:

apple
apples
applesauce
appetite

a query of "apples" should return only ["apples", "applesauce"]. A query of "" or "a", "ap" or "app" should return all words, since "" and the other substrings are a prefix to all words in the word list. Likewise, if no query is provided, return the entire word list. A query like "pple" would return nothing, because it's not a prefix of any words in the list.

The list of words that you'll be filtering for the challenge itself will be much larger (466,000 words) and should be obtained from the following URL: https://raw.githubusercontent.com/dwyl/english-words/master/words_alpha.txt. Your code should make a HTTP request to retrieve the text file contents. The file is ordered alphabetically, contains one word per line and consists entirely of lowercase letters separated by newlines.

All query strings will be matched exactly--there is no need to worry about case-insensitive matching or otherwise manipulating the incoming query.

Keep performance in mind when fetching this dictionary file.
Response format

All requests should respond with status code 200 on success and 404 when there are no results for a particular query. Success responses will consist of the following JSON structure:

{
  "data": [...]
}

In this structure, the actual response data (the alphabetized list of matching words for the query prefix) will be contained inside of the data array. For the above simplified example word list and a GET /?stem=apples, the expected response body should look like:

{
  "data": ["apples", "applesauce"]
}

Had the request been GET /?stem=zebra, return a 404 because "zebra" is not a prefix to any of the words in the simplified list.

You may wish to write a few of your own tests. A modifiable example file which will not be included with your final submission is located in tests/StemsControllerTests.cs. This file gives an idea of what the submission tests will consist of.
