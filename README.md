# GitForms

![VERSION](https://img.shields.io/badge/GitForms%20--%20version-v1.1.0-blue.svg)

Gitforms is a client application of the [**Github API**](https://api.github.com), this project was developed using the technology of Xamarin Forms, and can be exported to Android, iOS and Windows 10.

In this project was also used the plugin [**Xam.Plugins.Forms.ImageCircle**](https://www.nuget.org/packages/Xam.Plugins.Forms.ImageCircle/3.0.0.5)   
to leave the circular image.

In this app we have the following features:
- View your user information
	- https://api.github.com/users/USERNAME
- View your repositories
	- https://api.github.com/users/USERNAME/repos
- View your followers
	- https://api.github.com/users/USERNAME/followers
- View the users you are following
	- https://api.github.com/users/USERNAME/following

In this project was developed 4 pages:

- LoginPage
- MenuPage
- ReposPage
- FollowersPage
- FollowingPage

Among the components and layouts used in the project we have:

- ListView
- MasterDetailPage
- Image
- Button
- Entry
