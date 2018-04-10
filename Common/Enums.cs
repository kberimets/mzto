namespace Common
{
    public enum OikCategory
    {
        Ti = 1,
        UstorageHour = 2,
        UstorageDay = 3,
        UstorageMonth = 4
    }

    /// <summary>
    /// Типы параметров НСИ для центра питания.
    /// </summary>
    public enum MztoType
    {
        /// <summary>
        /// ТИ-источник
        /// </summary>
        SourceTi = 1,

        /// <summary>
        /// Pмакс. за час
        /// </summary>
        PmaxHour = 2,

        /// <summary>
        /// Pмакс. за сутки
        /// </summary>
        PmaxDay = 3,

        /// <summary>
        /// Pмакс. за месяц
        /// </summary>
        PmaxMonth = 4,

        /// <summary>
        /// Pмакс. за все время наблюдения
        /// </summary>
        PmaxAll = 5,

        /// <summary>
        /// Pсредн. за час
        /// </summary>
        PavgHour = 6,

        /// <summary>
        /// Pсредн. за сутки
        /// </summary>
        PavgDay = 7,

        /// <summary>
        /// Pсредн. за месяц
        /// </summary>
        PavgMonth = 8,

        /// <summary>
        /// Макс. из Рсредн. за месяц за все время наблюдения
        /// </summary>
        PavgAll = 9,

        /// <summary>
        /// Дата Pмакс. за месяц (с точностью до суток)
        /// </summary>
        DateMaxMonth = 10,

        /// <summary>
        /// Дата Pмакс. за все время наблюдения (с точностью до суток)
        /// </summary>
        DateMaxAll = 11,

        /// <summary>
        /// Дата, макс. из Рсредн. за месяц за все время наблюдения (с точностью до месяца)
        /// </summary>
        DateAvgAll = 12,

        /// <summary>
        /// Pмакс. по тех. условиям
        /// </summary>
        PmaxTc = 13
    }

}