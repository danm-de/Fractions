using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;

namespace Fractions.Benchmarks;

[MemoryDiagnoser]
// [ShortRunJob]
[MediumRunJob(RuntimeMoniker.Net48)]
[MediumRunJob(RuntimeMoniker.Net80)]
public class ExampleScenarioBenchmarks {

    /// <summary>
    /// The record as stored in database
    /// </summary>
    private class MedicineRecord {
        public int Id { get; set; }
        public decimal MassConcentrationPercent { get; set; }
    }

    /// <summary>
    /// The loaded medicine expressing the mass concentration percent as a fraction
    /// </summary>
    private class Medicine() {
        public int Id { get; set;  }
        public Fraction MassConcentrationMgMl { get; set; }
    }

    /// <summary>
    /// The configured infusion rates as stored in a database
    /// </summary>
    private class InfusionRateRangeRecord {
        public decimal MinWeight { get; set; }
        public decimal MaxWeight { get; set; }
        public decimal InfusionRateMgKgH { get; set; }
    }

    /// <summary>
    /// The loaded infusion rates 
    /// </summary>
    private class InfusionRateRange {
        public Fraction MinWeight { get; set; }
        public Fraction MaxWeight { get; set; }
        public Fraction InfusionRateMgKgH { get; set; }
    }

    /// <summary>
    /// The patient data as stored in a database
    /// </summary>
    private class PatientRecord {

        public string Name { get; set; }
        public decimal WeightKg { get; set; }
    }

    /// <summary>
    /// The patient information
    /// </summary>
    private class Patient {

        public string Name { get; set; }
        public Fraction WeightKg { get; set; } 
    }

    private List<MedicineRecord> MedicineRecords { get; set; }
    private List<InfusionRateRangeRecord> InfusionRates { get; set; }
    private List<PatientRecord> PatientRecords { get; set; }
    
    
    [GlobalSetup]
    public void GlobalSetup() {
        MedicineRecords = new List<MedicineRecord>();
        MedicineRecords.Add(new MedicineRecord { Id = 1, MassConcentrationPercent = 5.00m });
        MedicineRecords.Add(new MedicineRecord { Id = 2, MassConcentrationPercent = 7.05m  });
        MedicineRecords.Add(new MedicineRecord { Id = 3, MassConcentrationPercent = 15.0m });

        InfusionRates = new List<InfusionRateRangeRecord>();
        InfusionRates.Add(new InfusionRateRangeRecord { MinWeight = 50, MaxWeight = 60, InfusionRateMgKgH = 2.00m });
        InfusionRates.Add(new InfusionRateRangeRecord { MinWeight = 60, MaxWeight = 70, InfusionRateMgKgH = 2.75m });
        InfusionRates.Add(new InfusionRateRangeRecord { MinWeight = 70, MaxWeight = 80, InfusionRateMgKgH = 4.50m });
        InfusionRates.Add(new InfusionRateRangeRecord { MinWeight = 80, MaxWeight = 90, InfusionRateMgKgH = 5.00m });
        InfusionRates.Add(new InfusionRateRangeRecord { MinWeight = 90, MaxWeight = 100, InfusionRateMgKgH = 5.00m });

        PatientRecords = new List<PatientRecord>();
        PatientRecords.Add(new PatientRecord { Name = "John Doe", WeightKg = 90.0m });
        PatientRecords.Add(new PatientRecord { Name = "Mike Doe", WeightKg = 70.5m });
        PatientRecords.Add(new PatientRecord { Name = "Jane Smith", WeightKg = 65.2m });
        PatientRecords.Add(new PatientRecord { Name = "Mike Johnson", WeightKg = 80.7m });
        PatientRecords.Add(new PatientRecord { Name = "Sarah Johnson", WeightKg = 75.3m });
        PatientRecords.Add(new PatientRecord { Name = "Emily Johnson", WeightKg = 68.9m });
        
    }
    private class InfusionOption {
        public Patient Patient { get; set; }
        public Medicine Medicine { get; set; }
        public InfusionRateRange InfusionRate { get; set; }
        public Fraction MassInfusionRateMgH { get; set; }
        public Fraction VolumeInfusionRateMlH { get; set; }
        public Fraction DurationHours { get; set; }
        
    }

    private class PatientOptions {
        public List<InfusionOption> Options { get; set; }
        public Fraction AverageDuration { get; set; }
        public Fraction AverageAmount { get; set; }
    }

    [Benchmark(Baseline = true)]
    public int PrepareScheduleReduced() {
        return PrepareOptions(true).Count;
    }

    [Benchmark(Baseline = false)]
    public int PrepareScheduleNonReduced() {
        return PrepareOptions(false).Count;
    }

    private List<PatientOptions> PrepareOptions(bool reduceTerms) {
        var solutions = LoadSolutionsNormalized(reduceTerms);
        var infusionRates = LoadInfusionRateRanges(reduceTerms);
        var patients = LoadPatients(reduceTerms);
        var patientOptions = new List<PatientOptions>();
        
        foreach (var patient in patients) {
            var infusionOptions = new List<InfusionOption>();
            var infusionRate = GetInfusionRateForPatient(infusionRates, patient);
            var totalDuration = Fraction.Zero;
            var totalAmount = Fraction.Zero;
            foreach (var solution in solutions) {
                var scheduleItem = CreateScheduleItem(infusionRate, patient, solution);
                totalAmount += scheduleItem.MassInfusionRateMgH * scheduleItem.DurationHours;
                totalDuration += scheduleItem.DurationHours;
                infusionOptions.Add(scheduleItem);
            }

            patientOptions.Add(new PatientOptions {
                Options = infusionOptions,
                AverageAmount = totalAmount / infusionOptions.Count,
                AverageDuration = totalDuration / infusionOptions.Count
            });
        }

        return patientOptions;
    }


    private static InfusionOption CreateScheduleItem(InfusionRateRange infusionRate, Patient patient, Medicine solution) {
        var infusionRateMgH = infusionRate.InfusionRateMgKgH * patient.WeightKg;
        var infusionRateMlH = infusionRateMgH / infusionRate.InfusionRateMgKgH; // TODO should we multiply by the Reciprocal?
        var millilitersRequired = 50m; // TODO this should probably be based on the amount prescribed but i haven't modeled that
        var scheduleItem = new InfusionOption {
            Patient = patient,
            Medicine = solution,
            InfusionRate = infusionRate,
            MassInfusionRateMgH = infusionRateMgH,
            VolumeInfusionRateMlH = infusionRateMlH,
            DurationHours = infusionRateMlH / millilitersRequired
        };
        return scheduleItem;
    }

    private static InfusionRateRange GetInfusionRateForPatient(List<InfusionRateRange> infusionRates, Patient patient) {
        return infusionRates.Find(range => range.MinWeight >= patient.WeightKg && patient.WeightKg < range.MaxWeight)!;
    }

    private List<Medicine> LoadSolutionsNormalized(bool reduceTerms) {
        var result = new List<Medicine>();
        foreach (var medicineRecord in MedicineRecords) {
            result.Add(new Medicine {
                Id = medicineRecord.Id,
                MassConcentrationMgMl = Fraction.FromDecimal(medicineRecord.MassConcentrationPercent, reduceTerms) / 100 * 1000 });
        }

        return result;
    }

    private List<InfusionRateRange> LoadInfusionRateRanges(bool reduceTerms) {
        var result = new List<InfusionRateRange>();
        foreach (var rangeRecord in InfusionRates) {
            result.Add(new InfusionRateRange {
                InfusionRateMgKgH = Fraction.FromDecimal(rangeRecord.InfusionRateMgKgH, reduceTerms),
                MinWeight = Fraction.FromDecimal(rangeRecord.MinWeight, reduceTerms),
                MaxWeight = Fraction.FromDecimal(rangeRecord.MaxWeight, reduceTerms)
            });
        }

        return result;
    }

    private List<Patient> LoadPatients(bool reduceTerms) {
        var result = new List<Patient>();
        foreach (var patientRecord in PatientRecords) {
            result.Add(new Patient() {
                Name = patientRecord.Name,
                WeightKg = Fraction.FromDecimal(patientRecord.WeightKg, reduceTerms)
            });
        }
        return result;
    }
}
