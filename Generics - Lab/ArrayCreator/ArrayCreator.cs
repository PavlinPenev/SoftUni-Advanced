namespace GenericArrayCreator
{
    public static class ArrayCreator
    {
        public static T[] Create<T>(int length, T defaultItem)
        {
            T[] result = new T[length];
            for (int i = 0; i < length; i++)
            {
                result[i] = defaultItem;
            }

            return result;
        }
    }
}
