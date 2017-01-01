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

        public enum NationalOrigin
        {
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
            DominicanRepublic,
            Honduras,
            Paraguay,
            Nicaragua,
            ElSalvador,
            CostaRica,
            Panama,
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
            FrenchGuiana,
            SaintLucia,
            Curaçao,
            Aruba,
            SaintVincentandtheGrenadines,
            UnitedStatesVirginIslands,
            Grenada,
            AntiguanadBarbuda,
            Dominica,
            Bermuda,
            CaymanIslands,
            SaintKittsandNevis,
            SaintMaarten,
            TurksandCaicosIslands,
            SaintMartin,
            BritishVirginIslands,
            CaribbeanNetherlands,
            Anguilla,
            SaintBarthélemy,
            SaintPierreandMiquelon,
            Montserrat,
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