// ReSharper disable InconsistentNaming

using System.ComponentModel.DataAnnotations;

namespace MemigrationProBonoTracker.Models
{
    public class Enums
    {
        public enum CaseType
        {
            [Display(Name = "SIJS Predicate Order")]
            SIJSPredicateOrder,
            [Display(Name = "SIJS Adjustment Application")]
            SIJSAdjustmentApplication,
            [Display(Name = "UAC Asylum")]
            UACAsylum,
            [Display(Name = "AWC Asylum")]
            AWCAsylum,
            [Display(Name = "Asylum Other")]
            AsylumOther,
            [Display(Name = "U Visa")]
            UVisa,
            [Display(Name = "VAWA Self Petition")]
            VAWASelfPetition,
            [Display(Name = "VAWA Cancellation")]
            VAWACancellation,
            [Display(Name = "Asylee Adjustment of Status")]
            AsyleeAdjustmentofStatus,
            [Display(Name = "Naturalization")]
            Naturalization,
            [Display(Name = "DACA")]
            DACA,
            [Display(Name = "Family Based Petition")]
            FamilyBasedPetition,
            [Display(Name = "Removal Defense")]
            RemovalDefense,
            [Display(Name = "Other")]
            Other
        }

        public enum Gender
        {
            Female,
            Male,
            Other
        }

        public enum NumberType
        {
            Office,
            Cell,
            Fax,
            Home,
            Other
        }

        public enum Country
        {
            [Display(Name = "United States")]
            UnitedStates,
            Brazil,
            Mexico,
            Colombia,
            Argentina,
            Canada,
            Peru,
            Venezuela,
            Chile,
            Ecuador,
            Guatemala,
            Cuba,
            Haiti,
            Bolivia,
            [Display(Name = "Dominican Republic")]
            DominicanRepublic,
            Honduras,
            Paraguay,
            Nicaragua,
            [Display(Name = "El Salvador")]
            ElSalvador,
            [Display(Name = "Costa Rica")]
            CostaRica,
            Panama,
            [Display(Name = "Puerto Rico")]
            PuertoRico,
            Uruguay,
            Jamaica,
            [Display(Name = "Trinidad and Tobago")]
            TrinidadandTobago,
            Guyana,
            Suriname,
            Guadeloupe,
            Martinique,
            Bahamas,
            Belize,
            Barbados,
            [Display(Name = "French Guiana")]
            FrenchGuiana,
            SaintLucia,
            Curaçao,
            Aruba,
            [Display(Name = "Saint Vincent and the Grenadines")]
            SaintVincentandtheGrenadines,
            [Display(Name = "United States Virgin Islands")]
            UnitedStatesVirginIslands,
            Grenada,
            [Display(Name = "Antigua and Barbuda")]
            AntiguanadBarbuda,
            Dominica,
            Bermuda,
            [Display(Name = "Cayman Islands")]
            CaymanIslands,
            [Display(Name = "Saint Kitts and Nevis")]
            SaintKittsandNevis,
            [Display(Name = "Saint Maarten")]
            SaintMaarten,
            [Display(Name = "Turks and Caicos Islands")]
            TurksandCaicosIslands,
            [Display(Name = "British Virgin Islands")]
            BritishVirginIslands,
            [Display(Name = "Caribbean Netherlands")]
            CaribbeanNetherlands,
            Anguilla,
            [Display(Name = "Saint Barthélemy")]
            SaintBarthélemy,
            [Display(Name = "Saint Pierre and Miquelon")]
            SaintPierreandMiquelon,
            Montserrat,
            [Display(Name = "Falkland Islands")]
            FalklandIslands,
            Other
        }

        public enum RecruitmentMethod
        {
            [Display(Name = "In-Person Seminar")]
            InPersonSeminar,
            [Display(Name = "Webinar")]
            Webinar,
            [Display(Name = "Personal Contact")]
            PersonalContact,
            [Display(Name = "Other")]
            Other
        }
    }
}