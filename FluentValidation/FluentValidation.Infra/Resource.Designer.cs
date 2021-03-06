﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FluentValidation.Infra {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class Resource {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resource() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("FluentValidation.Infra.Resource", typeof(Resource).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Os campos &apos;Senha&apos; e &apos;ConfirmacaoSenha&apos; devem ser iguais..
        /// </summary>
        public static string ConfirmacaoSenha {
            get {
                return ResourceManager.GetString("ConfirmacaoSenha", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Já existe &apos;CPF&apos; cadastrado..
        /// </summary>
        public static string CPFCadastrado {
            get {
                return ResourceManager.GetString("CPFCadastrado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo &apos;CPF&apos; deve ser informado..
        /// </summary>
        public static string CPFInformado {
            get {
                return ResourceManager.GetString("CPFInformado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O numero informado não é um &apos;CPF&apos; válido..
        /// </summary>
        public static string CPFInvalido {
            get {
                return ResourceManager.GetString("CPFInvalido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo &apos;CPF&apos; deve possuir 11 caracteres..
        /// </summary>
        public static string CPFTamanho {
            get {
                return ResourceManager.GetString("CPFTamanho", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Já existe &apos;E-mail&apos; cadastrado..
        /// </summary>
        public static string EmailCadastrado {
            get {
                return ResourceManager.GetString("EmailCadastrado", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo &apos;Email&apos; deve ser informado..
        /// </summary>
        public static string EmailInformar {
            get {
                return ResourceManager.GetString("EmailInformar", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O valor informado no campo &apos;Email&apos; não é um e-mail válido..
        /// </summary>
        public static string EmailInvalido {
            get {
                return ResourceManager.GetString("EmailInvalido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O campo &apos;Email&apos; não deve conter mais que 50 caracteres..
        /// </summary>
        public static string EmailTamanho {
            get {
                return ResourceManager.GetString("EmailTamanho", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O &apos;{PropertyName}&apos; não pode ser editado..
        /// </summary>
        public static string ForcaCampoVazio {
            get {
                return ResourceManager.GetString("ForcaCampoVazio", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A senha deve conter entre 8 e 15 caracteres, pelo menos um número, pelo menos uma letra maiúscula e pelo menos uma letra minúscula..
        /// </summary>
        public static string SenhaValidacao {
            get {
                return ResourceManager.GetString("SenhaValidacao", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to O usuário deverá ter &apos;{PropertyName}&apos; superior a {idadeMinimaUsuario} anos..
        /// </summary>
        public static string ValidaIdade {
            get {
                return ResourceManager.GetString("ValidaIdade", resourceCulture);
            }
        }
    }
}
