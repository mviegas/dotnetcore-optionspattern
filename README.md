# Options Pattern

Some examples about the options pattern usage with .NET Core

## Create a simple POCO class to bind the settings file

That's self-explanatory :)

## Add configuration file to Startup.cs

We can bind the configuration file to our class in a couple of ways:

##### With the AddOptions method. It returns an ``OptionsBuilder``. This might be useful if you want to add some more configuration after configuring the binding.
``services.AddOptions<AppSettings>().Bind(Configuration);``

##### With the Configure method returns a ``IServiceCollection``.
``services.Configure<AppSettings>(Configuration);``

## Inject the IOptions<T> wherever you want to access it

Just put ``IOptions<T> options`` in the constructor of the class where you want to inject it. Remember to replace T with the type of the class you created in the first step.

Then you access the settings values calling the ``options.Value`` property.

## Validating a configuration

We can validate a configuration using the ``[Required]`` attribute in a property of our settings class and replacing the configuration in startup with the following:

``services.AddOptions<AppSettings>().Bind(Configuration).ValidateDataAnnotations();``

If a required property is missing in our settings file, a ``OptionsValidationException`` will be thrown when we call the ``Value`` property.

We can also apply validation with a ``Func<T, bool>``:

``
services.AddOptions<AppSettings>().Bind(Configuration).Validate(c => !string.IsNullOrEmpty(c.SomeRequiredConfiguration));
``
