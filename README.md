# Our.Umbraco.DocTypePicker

*Don't forget to do a NuGet restore.*

You can login to the website and test the Doc Type Picker. Here are the login details:

<strong>username:</strong> admin@admin.com<br/>
<strong>password:</strong> 1234567890

Usage:
1) Add the package via nuget: https://www.nuget.org/packages/Our.Umbraco.DocTypePicker/
2) Create a new Datatype in the Developer section of Umbraco
3) Select options:
  * Enable Single or Multi document type selection.
  * Decide on storage value i.e ID / Alias / Json structure
4) Add a new field to your page, and use the Doc Type Picker datatype.

*When creating the nuget package, use the following command*
nuget pack Our.Umbraco.DocTypePicker.csproj -Exclude bin/**/*.*
