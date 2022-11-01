namespace DevIO.App.Configurations
{
    public static class MvcConfig
    {
        public static IServiceCollection AddMvcConfiguration(this IServiceCollection services)
        {
            string ValorPreenchidoInvalido = "O valor preenchido é inválido para este campo.";
            string CampoPrecisaSerPreenchido = "Este campo precisa ser preenchido.";
            string BodyVazio = "É necessário que o body na requisição não esteja vazio.";
            string CampoNumerico = "O campo deve ser numérico.";

            services.AddControllersWithViews(o => { 
                o.ModelBindingMessageProvider.SetAttemptedValueIsInvalidAccessor((x, y) => ValorPreenchidoInvalido);
                o.ModelBindingMessageProvider.SetMissingBindRequiredValueAccessor(x => CampoPrecisaSerPreenchido);
                o.ModelBindingMessageProvider.SetMissingKeyOrValueAccessor(() => CampoPrecisaSerPreenchido);
                o.ModelBindingMessageProvider.SetMissingRequestBodyRequiredValueAccessor(() => BodyVazio);
                o.ModelBindingMessageProvider.SetNonPropertyAttemptedValueIsInvalidAccessor((x) => ValorPreenchidoInvalido);
                o.ModelBindingMessageProvider.SetNonPropertyUnknownValueIsInvalidAccessor(() => ValorPreenchidoInvalido);
                o.ModelBindingMessageProvider.SetNonPropertyValueMustBeANumberAccessor(() => CampoNumerico);
                o.ModelBindingMessageProvider.SetUnknownValueIsInvalidAccessor((x) => ValorPreenchidoInvalido);
                o.ModelBindingMessageProvider.SetValueIsInvalidAccessor((x) => ValorPreenchidoInvalido);
                o.ModelBindingMessageProvider.SetValueMustBeANumberAccessor(x => CampoNumerico);
                o.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(x => CampoPrecisaSerPreenchido);
            });

            return services;
        }
    }
}
